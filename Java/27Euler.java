
public class Euler27 {

 
    public static boolean isPrime(int n) {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++) {
            if (n % i == 0) return false;
        }
        return true;
    }

    public static int consecutivePrimes(int a, int b) {
        int n = 0;
        while (isPrime(n * n + a * n + b)) {
            n++;
        }
        return n;
    }

    public static void main(String[] args) {
        int maxPrimes = 0;
        int bestA = 0;
        int bestB = 0;
        for (int a = -999; a < 1000; a++) {
            for (int b = -1000; b <= 1000; b++) {
                int numPrimes = consecutivePrimes(a, b);
                if (numPrimes > maxPrimes) {
                    maxPrimes = numPrimes;
                    bestA = a;
                    bestB = b;
                }
            }
        }

}