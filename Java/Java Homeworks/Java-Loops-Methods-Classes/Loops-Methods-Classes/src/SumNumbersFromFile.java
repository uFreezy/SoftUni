import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.Scanner;

public class SumNumbersFromFile {

	public static void main(String[] args) {	
		try {
			String url = "/home/xubuntu/Java-Homeworks"
					+ "/Java-Loops-Methods-Classes/Loops-Methods-Classes/src/file.txt";
			FileReader file = new FileReader(url);
			Scanner input = new Scanner(file);
			int sum = 0;
			
			while(input.hasNextInt()) {
				sum += input.nextInt();
			}
			input.close();
			
			System.out.println(sum);
		} catch (FileNotFoundException e) {
			System.out.println("Error");
		}
	}
}
