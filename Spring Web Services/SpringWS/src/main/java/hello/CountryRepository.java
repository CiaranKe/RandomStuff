package hello;

import org.springframework.stereotype.Component;
import org.springframework.util.Assert;

import javax.annotation.PostConstruct;
import java.util.ArrayList;
import java.util.Currency;
import java.util.List;

/**
 * Created by ciaranke on 06/10/2014.
 */
@Component
public class CountryRepository
{
    private final List<Country> countries = new ArrayList<Country>();

    @PostConstruct
    public void initData() {
        Country spain = new Country();
        spain.setName("Spain");
        spain.setCapital("Madrid");
        spain.setCurrency(Currency.EUR);
        spain.setPopulation(46704314);
        countries.add(spain);

        Country uk = new Country();
        uk.setName("UK");
        uk.setCapital("London");
        uk.setCurrency(Currency.GBP);
        uk.setPopulation(6370500);
        countries.add(uk);

        Country poland = new Country();
        poland.setName("Poland");
        poland.setCapital("Warsaw");
        poland.setCurrency(Currency.PLN);
        poland.setPopulation(38186860);
        countries.add(poland);
    }

    public Country findCountry(String name) {
        Assert.notNull(name);

        Country result= null;

        for (Country c : countries) {
            if (name.equals(c.getName())) {
                result = c;
            }
        }

        return result;
    }
}
