
public class IPEntry {
	private String ipaddress;
	private String domainName;
	public IPEntry(String line){
		String[] lines=line.split(" ");
		domainName=lines[0];
		ipaddress=lines[1];
		
	}
	
	public String getDomainName(){
		return domainName;
	}
	
	public String getIp(){
		return ipaddress;
	}
	
}
