import java.util.Scanner;


public class EqualBitPairs {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		Boolean checkPairT = false;
		Boolean checkPairF = false;
		int count = 0;
		int copyN = n;
		
		for(int i = 0; i < Integer.toBinaryString(copyN).length(); i++) {
			
			if((1 & n) == 1) {
				checkPairF = false;
				if(checkPairT) {
					count++;
				}
				else {
					checkPairT = true;
				}
			}
			else if ((1 & n) == 0) {
				checkPairT = false;
				if(checkPairF) {
					count++;
				}
				else {
					checkPairF = true;
				}
			}
			n = n >>> 1;
		}
		System.out.println(count);

	}

}
