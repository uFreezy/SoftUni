import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Scanner;

public class ThreeLargestNumbers {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		BigDecimal[] values = new BigDecimal[n];

		for(int i = 0; i < n; i++) {
			values[i] = input.nextBigDecimal();
		}
		
		input.close();
		Arrays.sort(values);
		
		if(n <= 3) {
			for(int a = n-1; a >= 0; a--) {
				BigDecimal remainder = values[a].remainder(BigDecimal.ONE);
				BigDecimal zero = new BigDecimal("0");
				int asd = remainder.compareTo(zero);
				
				if(asd != 0) {
					System.out.printf("%s \n",values[a].toPlainString());
				}
				else {
					System.out.printf("%s \n",values[a].toPlainString());
				}
			}
		}
		else {
			for(int a = n-1; a > n-4; a--) {
				BigDecimal remainder = values[a].remainder(BigDecimal.ONE);
				BigDecimal zero = new BigDecimal("0");
				int asd = remainder.compareTo(zero);
				
				if(asd != 0) {
					System.out.printf("%s \n",values[a].toPlainString());
				}
				else {
					System.out.printf("%s \n",values[a].toPlainString());
				}
			}
		}
	}
}
