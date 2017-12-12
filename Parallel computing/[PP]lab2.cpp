# include <cmath>
# include <cstdlib>
# include <ctime>
# include <iomanip>
# include <iostream>

using namespace std;

int prime_number(int n)
{
    int prime;
    int total = 0;

    for (int i = 2; i <= n; ++i)
    {
        prime = 1;
        for (int j = 2; j <= (i + 1) / 2; j++)
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

int main(int argc, char *argv[]) {
    int n;
    int primes;

    cout << "  \nThe number of processes is 1" << "\n";
    cout << "\n";
    cout << "         N        Pi          Time\n";
    cout << "\n";

    n = 2;

    while (n <= 262144*2) {
        clock_t start = clock();
            primes = prime_number(n);
            cout << "  " << setw(8) << n
                 << "  " << setw(8) << primes
                 << "  " << setw(14) << double(clock() - start)/CLOCKS_PER_SEC << "\n";
        n *= 2;
    }

    cout << "  \nNormal end of execution.\n";

    return 0;
}
