import java.util.Scanner;

public class Largest3Rect {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String getInp =  input.nextLine();
		input.close();
		int rectNumbs =  getInp.length() - getInp.replaceAll("x", "").length();
		String[] split = new String[rectNumbs*2];
		int[] rectSums = new int[rectNumbs];
		int count = 0;
		int maxValue = 0;
		
		split = getInp.split("x|\\[");
		for(int i = 0; i < split.length; i++) {
			split[i] = split[i].replaceAll("\\W", "");
		}
		
		for(int i = 1; i < split.length ; i += 2) {
			int sum = Integer.parseInt(split[i]) * Integer.parseInt(split[i+1]);
			rectSums[count] = sum;
			count++;
		}
		
		maxValue = rectSums[0] + rectSums[1] + rectSums[2];
		
		for(int i = 0; i < rectSums.length - 2; i++) {
			int sum1 = rectSums[i] + rectSums[i+1] + rectSums[i+2];
		
			if(maxValue < sum1) {
				maxValue = sum1;
			}
		}
		System.out.println(maxValue);
	}
}