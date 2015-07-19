#include <stdio.h>

// O(N)

// Calculate sum of numbers from start to end (e.g., 1 to 5 = 15)
void PrintSumOfNumbers1(const unsigned int start, const unsigned int end){
	int i = 0;
	unsigned int result = 0;
	// This loop runs a simple operation (1 + end - start) times,
	// heavily dependent on the distance between the two numbers.
	// The worst case is then defined to be N, where
	//		N = 1 + end - start
	for (i = start; i <= end; i++){
		result += i; // This is a simple opeartion
	}
	printf("The sum of numbers from %lu to %lu is: %lu\n", start, end, result);
}

// Calculate sum of numbers from start to end (e.g., 1 to 5 = 15)
void PrintSumOfNumbers2(const unsigned int start, const unsigned int end){

	// The three lines here are simple operations:
	// These are already built in the ALU, so we can
	// actually consider them as taking constant time
	// to run.
	// Regardless of the distance between start and end,
	// this would never run slower or faster.
	// Thus the worst case is then defined to be a constant.
	int adder1 = start ? 0 : 1;
	int adder2 = start ? 1 : 0;
	unsigned int result = ((adder1 + start + end) * (adder2 + end - start)) / 2;
	printf("The sum of numbers from %lu to %lu is: %lu\n", start, end, result);

}


// This example should show the computation of the Big O of 
// the common sequence of statements.
int main(){


	int x = 0, y = 0;
	printf("Please enter two numbers and hit 'Enter', or use -1 -1 as input to end:");
	while (x > -1){
		scanf("%d ", &x);
		scanf("%d", &y);
		if (x >-1){
			PrintSumOfNumbers1(x, y);
			PrintSumOfNumbers2(x, y);
		}
	}


	int i = 0, N;
	
	printf("Please enter a number: ");
	scanf("%d", &N);
	
	// Big O number 1
	for (i = 0; i < N; i++){
		// This loop would be running, at worst
		// from 0 to N -1. Hence:
		// O(N) since 0 to N-1 is also 1-N

		if (N > 1)
			printf("O(N) == O(%d)", N);
		else
			printf("This only runs at worst once: O(N) == O(1)");
	}
	
	// Big O number 2
	int flag = 0;
	printf("Please press any number greater than 1...");
	while (!flag){
		// This would, at worst case, also
		// run N times: N is dependent on you
		// O(N) as well
		scanf("%d", &flag);
	}


	int toSort[9] = { 11, 2, 4, 1, 1, 3, 9, 8, 1 };

	// Perform a simple sort operation
	int j = 0;
	int swapValue = 0;
	
	// Loop1
	for (i = 8; i > 0; i--){
		// Loop2

		// The BigO for the first loop, as was
		// explained in the previous examples, is O(N)
		// Since we have nested loops, loop number 2
		// runs N times in one iteration of loop 1
		// Thus, the worst case is N * N giving us a Big O
		// of O(N^2)


		for (j = 0; j < i; j++){
			if (toSort[i] < toSort[j]){
				swapValue = toSort[j];
				toSort[j] = toSort[i];
				toSort[j] = swapValue;
			}
		}
	}

	return 0; // on normal termination
}