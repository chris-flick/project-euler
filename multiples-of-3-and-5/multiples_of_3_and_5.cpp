#include <iostream>

using namespace std;

/**
 * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
 * The sum of these multiples is 23.
 *
 * Find the sum of all the multiples of 3 or 5 below 1000.
 */ 
int main() {
    int max = 1000, sum = 0;
    int multiples[max];
    int current_index = 0;

    int current_multiple_of_3 = 3;
    int current_multiple_of_5 = 5;

    while (current_multiple_of_3 < max || current_multiple_of_5 < max) {
        if (current_multiple_of_3 < max && (current_multiple_of_3 % 5 != 0)) {
            multiples[current_index] = current_multiple_of_3;
            current_index++;
        }

        if (current_multiple_of_5 < max) {
            multiples[current_index] = current_multiple_of_5;
            current_index++;
        }

        current_multiple_of_3 += 3;
        current_multiple_of_5 += 5;
    }

    for (int i = 0; i < current_index; i++) {
        sum += multiples[i];
    }

    cout << sum << endl;
    return 0;
}