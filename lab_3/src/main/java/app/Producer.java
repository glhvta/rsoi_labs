package app;

import javax.annotation.Resource;
import javax.ejb.LocalBean;
import javax.ejb.Schedule;
import javax.ejb.Stateless;
import javax.jms.*;

import static app.Config.JMS_TYPE;

@Stateless
@LocalBean
public class Producer {
    @Resource(lookup  = "java:/ConnectionFactory")
    private ConnectionFactory connectionFactory;

    @Resource(lookup  = "java:/jms/"+ JMS_TYPE +"/test")
    private Destination destination;

    @Schedule(hour = "*", minute = "*", second = "*/3", persistent = false)
    public void produceMessage() {
        try {
            Connection connection = connectionFactory.createConnection();
            Session session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE);
            MessageProducer messageProducer = session.createProducer(destination);

            messageProducer.send(session.createTextMessage("PRODUCER message :)"));
            System.out.println("____________________________________________________");

            connection.close();
            session.close();
        } catch(JMSException e) {
            e.printStackTrace();
        }

    }
}
