using System;
using UnityEngine;

public class Tests : MonoBehaviour {
    
    void Start() {
        print(createRandomNumber(1, 1, 10, 999));
        print(createRandomNumber(1, 1, 10, 999));
        print(createRandomNumber(1, 1, 10, 999));
        print(createRandomNumber(2, 2, 10, 999));
        print(createRandomNumber(2, 2, 10, 999));
        print(createRandomNumber(2, 2, 10, 999));
        print(createRandomNumber(3, 3, 10, 999));
        print(createRandomNumber(3, 3, 10, 999));
        print(createRandomNumber(3, 3, 10, 999));
    }

    public static int persistence(long n) {
        string numberToString = n.ToString();

        if (numberToString.Length == 1) {
            return 0;
        } else {
            int numberToMultiply = 1;
            int quantityOfMultiplications = 0;
            while (numberToString.Length != 1) {
                numberToMultiply = 1;

                for (int i = 0; i < numberToString.Length; i++) {
                    numberToMultiply *= (int)(numberToString[i] - '0');
                    if (i == 0) {
                        quantityOfMultiplications++;
                    }
                }

                numberToString = Convert.ToString(numberToMultiply);
            }

            return quantityOfMultiplications;
        }
    }

    public static int createRandomNumber(int minDepth, int maxDepth, int minRange, int maxRange) {
        int number = 0;

        while (number == 0){
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            int numberToCheck = UnityEngine.Random.Range(minRange, maxRange);
            print("Trying : " + numberToCheck);
            int depthToCheck = persistence(numberToCheck);
            print("Found : " + depthToCheck);
            if (minDepth <= depthToCheck && maxDepth >= depthToCheck) {
                number = numberToCheck;
            }
        }
        
        print("CORRECT : " + number);

        return number;
    }

    public static int multiplyAllDigits(int n) {
        string numberToString = n.ToString();
        int numberToMultiply = 1;

        for (int i = 0; i < numberToString.Length; i++) {
            numberToMultiply *= (int)(numberToString[i] - '0');
        }

    return numberToMultiply;
    }
}
