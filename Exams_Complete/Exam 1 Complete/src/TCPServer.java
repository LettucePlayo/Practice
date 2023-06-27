import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.sql.SQLException;
import java.util.List;

public class TCPServer {
    private ServerSocket serverSocket;
    private int port;
    private File f;
    private VectorThread vt;

    public void startTCPServer() throws IOException {
        Socket socket = serverSocket.accept();
        while(true) {
            try (BufferedReader reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                 ObjectOutputStream oos = new ObjectOutputStream(socket.getOutputStream())) {

                vt = new VectorThread(f.getAbsolutePath());
                List<Vehicle> list = vt.getCarList();

                String line;
                while ((line = reader.readLine()) != null) {
                    if (line.equals("EXIT")) {
                        socket.close();
                        return;
                    } else if (line.equals("GETFILE")) {
                        oos.writeObject(list);
                        oos.flush();
                    } else if (line.equals("GETJSON")) {
                        JSONArray array = new JSONArray();
                        for (var vehicle : list) {
                            try {
                                Car car = (Car) vehicle;
                                JSONObject object = new JSONObject();
                                object.put("weight", car.getWeight());
                                object.put("price", car.getPrice());
                                object.put("producer", car.getProducer());
                                array.put(object);
                            } catch (JSONException e) {
                                throw new RuntimeException(e);
                            }
                        }
                        oos.writeUTF(array.toString());
                        oos.flush();
                    } else if (line.equals("GETDB")) {
                        try {
                            UtilsDAO.setConnection();
                            oos.writeUTF(UtilsDAO.selectData());
                            oos.flush();
                            UtilsDAO.closeConnection();
                        } catch (SQLException e) {
                            throw new RuntimeException(e);
                        }
                    }
                }

            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }

    }

    public TCPServer(int port) throws Exception {
        this.port = port;
        serverSocket = new ServerSocket(port);
    }

    public void setF(String f) {
        if(f != null)
            this.f = new File(f);
        else
            this.f = null;
    }

    public int getPort() {
        return port;
    }

    public void setPort(int port) {
        this.port = port;
    }
}
