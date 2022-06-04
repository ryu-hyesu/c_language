#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
int pick(int itemSize, int* bucket, int bucketSize, int k,int n){
	int smallest, lastIndex, item;
	int i, sum = 0, count = 0;

	for (i = 0; i < bucketSize - k; i++)
		sum += bucket[i];

	if (sum == n) return 1;
	if (sum > n) return 0;
	if (k == 0) return 0;

	lastIndex = bucketSize - k - 1;
	if (bucketSize == k)
		smallest = 1;
	else
		smallest = bucket[lastIndex];

	for (item = smallest; item <= itemSize; item++) {
		bucket[lastIndex + 1] = item;
		count += pick(itemSize, bucket, bucketSize,k - 1,n);
	}
	return count;

}
int main()
{
	int n;
	scanf("%d", &n);
	int* picked = (int*)malloc(sizeof(int) * n);

	printf("%d", pick(2, picked, n, n, n));
}