import java.util.Scanner;

public class ThreeLetterWords {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		char[] letters =  input.nextLine().toCharArray();
		input.close();
		int length = letters.length;
		int counter = 0;
		
		for(int l1 = 0; l1 < length; l1++) {
			for(int l2 = 0; l2 < length; l2++) {
				for(int l3 = 0; l3 < length; l3++) {	
					if(counter == 10) {
						System.out.println();
						counter = 0;
					}
					System.out.printf("%s%s%s ",letters[l1],letters[l2],letters[l3]);
					counter++;
				}
			}
		}
	}
}
