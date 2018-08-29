import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashSet;
import java.util.List;
import java.util.Scanner;
import java.util.Set;

public class CouplesFrequency {
	private static int getFrequency(List<String> a,String b) {
		int getFreq = 0; 
		getFreq += Collections.frequency(a, b);
		return getFreq;
	}
	
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inp = input.nextLine();
		input.close();
		
		List<String> eles = new ArrayList<String>(Arrays.asList(inp.split(" ")));
		List<String> elesClean = new ArrayList<String>();
		Set<String> set = new HashSet<String>(); // Removes duplicate values
		float prcEle = 0;
		
		for(int i = 0; i < eles.size()-1; i++ ) {
			String buffer = eles.get(i) + " " + eles.get(i + 1);
			eles.set(i, buffer);	
		
		}
		if(!eles.get(eles.size()-1).contains(" ")) {
			eles.remove(eles.size()-1);
		}
		
		set.addAll(eles);
		elesClean.addAll(set);
		
		for(int k = 0; k < elesClean.size()-1; k++) {
			for(int i = 0; i < elesClean.size()-1; i++) {
				for(int m = 0; m < eles.size(); m++) {
					if(eles.get(m) == elesClean.get(i)) {
						break;
					}
					else if(eles.get(m) == elesClean.get(i+1)) {
							String buffer = elesClean.get(i);
							elesClean.set(i,elesClean.get(i+1));
							elesClean.set(i+1, buffer);
							break;
					}
				}
			}
		}
		
		prcEle =  (float)100 / eles.size();
		char pr = '\u0025';
		
		for(int i = 0; i < elesClean.size(); i++) {
			System.out.printf("%s -> %.2f%c  \n",elesClean.get(i),
					prcEle*getFrequency(eles,elesClean.get(i)),pr);
		}
	}
}
