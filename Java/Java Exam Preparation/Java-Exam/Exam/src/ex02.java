import java.util.Scanner;

public class ex02 {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] comb = input.nextLine().split(" ");
		input.close();
		double sum = 0;

		for (int i = 0; i < comb.length; i++) {
			comb[i] = comb[i].trim();
		}
		
		for (int i = 0; i < comb.length; i++) {
			if (!comb[i].isEmpty()) {
				if (Character.isUpperCase(comb[i].charAt(0))) {
					double currentSum = 0;

					currentSum += (double) Integer.parseInt((comb[i].replaceAll("[\\D]", "")))
							/ (1 + (comb[i].charAt(0) - 'A'));
		
					if (Character.isUpperCase(comb[i].charAt(comb[i].length() - 1))) {
						currentSum = currentSum - (1 + (comb[i].charAt(comb[i].length() - 1) - 'A'));
						sum += currentSum;
					} else {
						currentSum = currentSum + (1 + (comb[i].charAt(comb[i].length() - 1) - 'a'));
						sum += currentSum;
					}
				} else {
					double currentSum = 0;
					currentSum += (double) Integer.parseInt(comb[i].replaceAll("[\\D]", ""))
							* (1 + (comb[i].charAt(0) - 'a'));
					
					if (Character.isUpperCase(comb[i].charAt(comb[i].length() - 1))) {
						currentSum = currentSum - (1 + (comb[i].charAt(comb[i].length() - 1) - 'A'));
						sum += currentSum;
					} else {
						currentSum = currentSum + (1 + (comb[i].charAt(comb[i].length() - 1) - 'a'));
						sum += currentSum;
					}
				}
			}
		}
		
		System.out.printf("%.2f", sum);
	}
}