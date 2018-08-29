import java.util.Scanner;

public class VideoDurations {
	public static void main (String[] args) {
		int hours = 0;
		int mins = 0;
		Scanner scan = new Scanner(System.in);
		String input = "";
		
		while(true) {
			input = scan.nextLine();
		
			if(input.equals("End")) {
				if(mins < 10)
				{
					System.out.println(hours + ":" + "0" + mins);
				}
				else {
					System.out.println(hours + ":" + mins);
				}
				scan.close();
				break;
			}
			
			String[] parts = input.split(":");
			hours += Integer.parseInt(parts[0]);
			mins += Integer.parseInt(parts[1]);
			
			if(mins > 59) {
				mins -= 60;
				hours++;
			}
		}
	}
}