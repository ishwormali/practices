import java.io.IOException;


public class IPLookup {

	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub

		IPDatabase db=new IPDatabase("D:\\datalist.txt");
		System.out.println(db.findIPAddress("www.princeton.edu"));
		System.out.println(db.findDomainName("128.103.60.24"));
		

	}

}
