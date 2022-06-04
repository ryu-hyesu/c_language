#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
int pick(int* itemBucket, int itemSize, int* bucket, int bucketSize, int k, int total){
	int smallest, lastIndex, item;
	int diff,sub_sum,sum=0;
	int min = total;
	
	if (k == 0) {
		for (int i = 0; i < bucketSize; i++)
			sum += itemBucket[bucket[i]];
		sub_sum = total - sum;
		return abs(sum - sub_sum);
	}

	lastIndex = bucketSize - k - 1;

	if (bucketSize == k)
		smallest = 0;
	else
		smallest = bucket[lastIndex] + 1;

	for (item = smallest; item < itemSize; item++) {
		bucket[lastIndex + 1] = item;
		diff = pick(itemBucket, itemSize, bucket, bucketSize,k - 1, total);
		if (min > diff)
			min = diff;
	}
	return min;
}
int main()
{
	int n = 6;
	int total = 0;
	int* item = (int*)malloc(sizeof(int) * n);
	int* picked = (int*)malloc(sizeof(int) * n / 2);

	for (int i = 0; i < n; i++) {
		scanf("%d", &item[i]);
		total += item[i];
	}

	printf("%d", pick(item, n, picked, n / 2, n / 2, total));
}