import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;

public class Orders {
	public static String getEle(List<String> list, String eleToSort) {
		Set<String> clear = new HashSet<String>(); // to remove duplicate names
		List<String> names = new ArrayList<String>(); // contains the names
		String output = "";
		
		for(String ele : list) {
			int indx = ele.indexOf(' ');
			names.add(ele.substring(0, indx)); // gets only the first word from the list
		}
		
		clear.addAll(names);
		names.removeAll(names);
		names.addAll(clear); // re-adds all names without duplicates
		Collections.sort(names); 
		Map<String,Integer> map = new HashMap<String,Integer>();
		
		for(String ele : names) {
			map.put(ele, 0);
		}
		
		for(String ele : list) {
			if(ele.contains(eleToSort)) {
				String[] getNumb = ele.split(" ");
				map.put(getNumb[0], map.get(getNumb[0]) + Integer.parseInt(getNumb[1]));
			}
		}
		
		for(String ele : names) {
			if(map.get(ele) > 0) {
				output +=  ' '+ele +' '+ map.get(ele)+',';
			}
		}
		
		output = output.substring(0, output.length()-1);
		return output;
	}
	
	public static List<String> getOrd(List<String> input) {
		List<String> data = new ArrayList<String>();
		LinkedHashSet<String> cleanDup = new LinkedHashSet<String>();
		
		for(String ele : input) {
			String[] split = ele.split(" ");
			data.add(split[2]);
		}
		cleanDup.addAll(data);
		data.removeAll(data);
		data.addAll(cleanDup);
		
		return data;
	}
	
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine(); // to clear the buffer
		List<String> inpList = new ArrayList<String>();
		String inp;
		
		for(int i = 0; i < n; i++) {
			inp = input.nextLine();
			inpList.add(inp);
		}
		
		input.close();
		List<String> orders = getOrd(inpList);
		
		for(String ele : orders) {
			System.out.printf("%s:%s",ele,getEle(inpList,ele));
			System.out.println();
		}
	}
}