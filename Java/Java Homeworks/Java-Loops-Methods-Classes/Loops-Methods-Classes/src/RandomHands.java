import java.util.Random;
import java.util.Scanner;

public class RandomHands {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		String[] cards = {"2","3","4","5","6","7","8","9","10","J","Q","K","A"};
		char[] paints = {'♣','♦','♥','♠'};
		int n = input.nextInt();
		input.close();
		Random rand = new Random();
		
		for(int i = 0; i < n; i++) {
			for(int a = 0; a < 5; a++) {
				int card = rand.nextInt(13);
				int paint = rand.nextInt(4);
				System.out.printf("%s%s ",cards[card],paints[paint]);
			}
			
			System.out.println();
		}

	}

}
