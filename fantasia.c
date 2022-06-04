#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
int main()
{
	int n, m;
	int rootN = 1, rootM = 1;
	int IN = 0, IM = 1, rN = 1, rM = 0;
	int midN, midM;

	scanf("%d %d", &n, &m);
	double answer = (double)n / m;
	midN = IN + rN;
	midM = IM + rM;
	
	while (midN != n || midM != m) {
		if ((double)midN / midM > answer) {
			rN = midN;
			rM = midM;
			midN = midN + IN;
			midM = midM + IM;
			printf("L");
		}
		else {
			IN = midN;
			IM = midM;
			midN = midN + rN;
			midM = midM + rM;
			printf("R");
		}

	}
	
}