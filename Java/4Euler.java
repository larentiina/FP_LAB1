public class 4Euler{

    private static boolean isPalindrom(int n){
        String str = String.valueOf(n);
        if(str.length()==6){
            return (str.charAt(0) == str.charAt(5)) && str.charAt(1) == str.charAt(4) && str.charAt(2) == str.charAt(3);
        }
        return false;
    }

    public static int solveProblem(){
        int max = 0;
        for(int i = 100; i<=999;i++){
            for(int j = i; j<=999;j++){
                if(isPalindrom(i*j)){
                    max = Math.max(max,i*j);
                }
            }
        }
        return max;
    }

}