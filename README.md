# Booking Console App

# To run this application, you need the following:

# Json files
- If you need to modify the booking or hotel data, navigate to the "Files" folder and make the necessary changes there.

# How to run?

### 1. Clone repository
```bash
git clone https://github.com/BartlomiejGromada/booking-console-app
```

### 2. Navigate to the project directory:
```bash
cd booking-console-app
```

### 3. Run the process of building a Docker image based on the Dockerfile located in the current directory by using the command:
```bash
docker build -t booking-app .
```

### 4. Run app by this command:
```bash
docker run -it booking-app
```