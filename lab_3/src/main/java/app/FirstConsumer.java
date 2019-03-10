package app;

import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.TextMessage;

import static app.Config.JMS_TYPE;

@MessageDriven(name = "FirstConsumer",
activationConfig = {
    @ActivationConfigProperty(propertyName = "destination", propertyValue = "java:/jms/"+ JMS_TYPE +"/test")
})
public class FirstConsumer implements MessageListener {
    @Override
    public void onMessage(Message message) {
        TextMessage textMessage = (TextMessage) message;
        try {
            System.out.println(textMessage.getText() + ": from FirstConsumer");
        } catch (JMSException e) {
            e.printStackTrace();
        }
    }
}
