# include <cmath>
# include <cstdlib>
# include <ctime>
# include <iomanip>
# include <iostream>
# include <mpi.h>
# include <vector>

using namespace std;

int prime_number(int n, int id, int p)
{
	int i;
	int j;
	int prime;
	int total = 0;

	for (i = 2 + id; i <= n; i += p)
	{
		prime = 1;
		for (j = 2; j <= (i + 1) / 2; j++)
		{
			if ((i % j) == 0)
			{
				prime = 0;
				break;
			}
		}
		total += prime;
	}
	return total;
}

void timestamp()
{
# define TIME_SIZE 40

	static char time_buffer[TIME_SIZE];
	const struct tm *tm;
	size_t len;
	time_t now;

	now = time(NULL);
	tm = localtime(&now);

	len = strftime(time_buffer, TIME_SIZE, "%d %B %Y %I:%M:%S %p", tm);

	cout << time_buffer << "\n";

	return;
# undef TIME_SIZE
}

int main(int argc, char *argv[])
{
	int i;
	int id;
	int n;
	int n_factor;
	int n_hi;
	int n_lo;
	int p;
	int ierr;
	int primes;
	int primes_part;
	double wtime;

	n_lo = 2;
	n_hi = 262144*2;

	ierr = MPI_Init(&argc, &argv);

	ierr = MPI_Comm_size(MPI_COMM_WORLD, &p);

	ierr = MPI_Comm_rank(MPI_COMM_WORLD, &id);

	if (id == 0)
	{
		timestamp();
		cout << "  \nThe number of processes is " << p << "\n";
		cout << "\n";
		cout << "         N        Pi          Time\n";
		cout << "\n";
	}

	n = n_lo;
	
	while (n <= n_hi)
	{
		if (id == 0)
		{
			wtime = MPI_Wtime();
		}
		ierr = MPI_Bcast(&n, 1, MPI_INT, 0, MPI_COMM_WORLD);

		primes_part = prime_number(n, id, p);

		ierr = MPI_Reduce(&primes_part, &primes, 1, MPI_INT, MPI_SUM, 0,
			MPI_COMM_WORLD);

		if (id == 0)
		{
			wtime = MPI_Wtime() - wtime;

			cout << "  " << setw(8) << n
				<< "  " << setw(8) << primes
				<< "  " << setw(14) << wtime << "\n";
		}
		n *= 2;
	}

	MPI_Finalize();

	if (id == 0)
	{
		cout << "  \nNormal end of execution.\n";
		timestamp();
	}

	return 0;
}
