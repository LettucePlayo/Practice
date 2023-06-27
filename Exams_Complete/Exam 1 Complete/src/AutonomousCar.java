public class AutonomousCar extends Car {
    private int softwareVersion;

    @Override
    public String infoVehicle() {
        return String.valueOf(softwareVersion);
    }

    @Override
    public String toString() {
        return "AutonomousCar{" +
                "softwareVersion=" + softwareVersion +
                '}';
    }

    public int getSoftwareVersion() throws Exception {
        if(softwareVersion > 0)
            return softwareVersion;
        else
            throw new Exception();
    }

    public void setSoftwareVersion(int softwareVersion) {
        this.softwareVersion = softwareVersion;
    }
}
