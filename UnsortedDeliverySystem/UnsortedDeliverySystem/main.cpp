#include <stdio.h>

#define T 10

/// <summary>
/// Check whether the sequence of length objects starting from start
/// are sorted.
/// Returns 0 if sorted, 1 if unsorted
/// </summary>
int isUnsorted(int *input, int start, int length){
	int i, j;
	int rVal = 0;
	// if we detect that the sequence is unsorted,
	// we break the loop and return the result
	for (i = start + length - 1; i > start && rVal == 0; i--){
		for (j = start; j < i && rVal == 0; j++){
			if (input[j] > input[j + 1]){
				rVal = 1;
			}
		}
	}
	return rVal;
}

int main(){
	int x, test_case, N;

	for (test_case = 0; test_case < T; test_case++){
		// Max input size, as per problem stated is 
		// N =20 -> NxN = 400
		int input[400] = { 0 };

		// Get the value of N
		// N is the number of items that should be sorted
		scanf("%d ", &N);

		// Get the sequence of integers of size NxN
		for (x = 0; x < N * N; x++){
			scanf("%d ", &input[x]);
		}

		// declare the answer variable
		int answer = 0;

		// Place algo here
		int i, j;

		// This is the bubble sort algorithm
		for (i = N - 1; i > 0; i--){
			for (j = 0; j < i; j++){
				// Bubble-sort optimization
				// Add a flag in case a swap has occured, then check that flag to figure out
				// if you still need to do subsequent swaps
			}
		}

		// Let's use a modified bubble sort algorithm
		for (i = 0; i < N; i++){
			answer += isUnsorted(input, i * N, N);
		}
		printf("%d\n", answer);
	}
	// return 0 on normal termination
	return 0;
}