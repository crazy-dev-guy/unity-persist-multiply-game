using System;
using UnityEngine;

public class Tests : MonoBehaviour {
    
    void Start() {
        print(Persistence(39));
        print(Persistence(999));
        print(Persistence(11));
        print(Persistence(4));
    }

    public static int Persistence(long n) {
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
}
