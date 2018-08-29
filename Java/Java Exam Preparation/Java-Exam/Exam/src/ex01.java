import java.util.Scanner;

public class ex01 {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String mood;
		int happiness = input.nextInt();
		input.nextLine();
		String[] getMeal = input.nextLine().split("\\W");
		input.close();

		for (int i = 0; i < getMeal.length; i++) {
			getMeal[i] = getMeal[i].replaceAll("(\\W)|(_)", "");
			getMeal[i] = getMeal[i].toLowerCase();
		}

		for (int i = 0; i < getMeal.length; i++) {
			if (getMeal[i].equals("cram")) {
				happiness += 2;
			} else if (getMeal[i].equals("lembas")) {
				happiness += 3;
			} else if (getMeal[i].equals("apple")) {
				happiness += 1;
			} else if (getMeal[i].equals("melon")) {
				happiness += 1;
			} else if (getMeal[i].equals("honeycake")) {
				happiness += 5;
			} else if (getMeal[i].equals("mushrooms")) {
				happiness -= 10;
			} else if (getMeal[i].equals("")) {
			} else {
				happiness -= 1;
			}
		}

		if (happiness <= -6) {
			mood = "Angry";
		} else if (happiness >= -5 && happiness <= -1) {
			mood = "Sad";
		} else if (happiness >= 0 && happiness < 15) {
			mood = "Happy";
		} else {
			mood = "Happy Javascript mood";
		}

		System.out.println(happiness);
		System.out.println(mood);
	}
}