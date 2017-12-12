#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <algorithm>
#include <string>
#include <vector>
#include <map>
#include <set>
#include <deque>
#include <stack>
#include <queue>
#include <math.h>
#include <iomanip>
#include <fstream>
#include <bitset>

#define pi 3.14159265358979323846
#define pb push_back
#define mp make_pair
#define endl "\n"
#define pll pair<ll, ll>
#define rep(i,n) for(int i = 0; i < n; ++i)
#define repo(i,n) for(int i = 1; i <= n; ++i)

typedef unsigned long long ull;
typedef long long ll;

ll gcd(ll a, ll b) {
	while (b) {
		a %= b;
		std::swap(a, b);
	}
	return a;
}

ll lcm(ll a, ll b) {
	return a / gcd(a, b) * b;
}

ll fac(ll n) {
	ll an = 1;
	while (n > 1)
	{
		an *= n;
		n--;
	}
	return an;
}

ll kor(ll n, ll st) {
	int res = 1;
	while (st) {
		if (st & 1)
			res *= n;
		n *= n;
		st >>= 1;
	}
	return res;
}

bool isprime(ll p) {

	if (p < 2) return false;
	if (p == 2) return true;
	if (p % 2 == 0) return false;

	double limit = sqrt(p);

	for (ll i = 3; i <= limit; i += 2) {
		if ((p % i) == 0) return false;
	}

	return true;
}

#define NMAX 1000000007 //10e9+7
#define N 1001

bool isConnected(int n, std::vector<std::vector<int> > &g)
{
#pragma region BFS
	std::queue<int> q;
	std::vector<char> used(n + 1);
	q.push(1);
	used[1] = true;

	while (!q.empty())
	{
		int v = q.front();
		q.pop();
		rep(i, g[v].size())
			if (!used[g[v][i]])
			{
				used[g[v][i]] = true;
				q.push(g[v][i]);
			}
	}
#pragma endregion

	repo(i, n)
		if (!used[i])
			return false;
	return true;
}

int main()
{
	freopen("input.txt", "r", stdin);
	freopen("output.txt", "w", stdout);
	std::ios::sync_with_stdio(0);
	std::cin.tie();

	int n, e;
	std::cin >> n >> e;
	std::vector<std::vector<int> > g(n + 1, std::vector<int>());
	rep(i, e)
	{
		int v1, v2;
		std::cin >> v1 >> v2;
		g[v1].pb(v2);
		g[v2].pb(v1);
	}

	if (!isConnected(n, g))
	{
		std::cout << "Graph isn't connected";
	}
	else
	{
		int mn = NMAX;
		int vert;
		repo(i, n)
		{
			if (g[i].size() < mn)
			{
				mn = g[i].size();
				vert = i;
			}
		}
		std::cout << "Minimum edges to delete: " << mn << endl;
		rep(i, g[vert].size())
		{
			std::cout << vert << " " << g[vert][i] << endl;
		}
	}
	return 0;
}

