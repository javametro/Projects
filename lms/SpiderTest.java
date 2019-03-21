import java.util.LinkedList;
import java.util.List;

public class SpiderTest
{
    /**
     * This is our test. It creates a spider (which creates spider legs) and crawls the web.
     * 
     * @param args
     *            - not used
     */
    public static void main(String[] args)
    {
        Spider spider = new Spider();
        spider.search("https://www.qq.com/", "lenovo");
		List<String> links = spider.pagesToVisit;
		
		for (int i = 0; i < links.size(); i++) {
			System.out.println(links.get(i));
		}
    }
}