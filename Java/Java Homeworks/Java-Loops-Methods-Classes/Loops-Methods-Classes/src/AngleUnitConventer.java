import java.util.Scanner;

public class AngleUnitConventer {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		String[] strVal = new String[n+1];
		
		for(int i = 0; i <= n; i++) {
			strVal[i] = input.nextLine();
		}
		
		input.close();
		
		for(int i = 0; i <= n; i++) {
			if(strVal[i].contains("deg")) {
				double value = Double.parseDouble(strVal[i].replace(" deg",""));
				System.out.printf("%.6f rad",getRadians(value));
				System.out.println();
			}
			else if(strVal[i].contains("rad")) {
				double value = Double.parseDouble(strVal[i].replace(" rad",""));
				System.out.printf("%.6f deg",getDeg(value));
				System.out.println();
			}
		}

	}
	public static double getRadians(double deg) {
		return Math.toRadians(deg);
	}
	
	public static double getDeg(double rad) {
		return Math.toDegrees(rad);
	}

}
