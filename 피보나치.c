#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
int fibonaci(int n, int* M) {
	if (n == 0 || n == 1) 
		M[n]++;
	else 
		fibonaci(n - 1, M) + fibonaci(n - 2, M);
	
}
int main()
{	
	int n;
	scanf("%d", &n);

	int M[2] = { 0,0 };

	fibonaci(n, M);
	printf("%d %d", M[1], M[0]);
}