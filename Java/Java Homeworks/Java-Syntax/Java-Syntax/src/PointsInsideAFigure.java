import java.util.Scanner;


public class PointsInsideAFigure {

	public static void main(String[] args) {
		
		float maxY = 13.5F;
		float maxX = 22.5F;
		float minY = 6F;
		float minX = 12.5F;
		Scanner input = new Scanner(System.in);
		float inpX = input.nextFloat();
		float inpY = input.nextFloat();
		
		if(inpX > 17.5 && inpX < 20) {
			maxY = 8.5F;
		}
		if(inpY >= minY && inpY <= maxY && inpX >= minX && inpX <= maxX) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}
		
		

	}

}
