#define led1 2
#define led2 3

void setup() {
  // Start Serial communication at 9600 baud rate
  Serial.begin(9600);
  // Wait for the Serial connection to establish
  while (!Serial) {
    ; // Wait until Serial is ready
  }
  Serial.println("Serial Communication Ready. Send data:");
}

void loop() {
  String duLieu = "";

  // Check if data is available on the Serial port
  if (Serial.available() > 0) {
    // Read the incoming data
    duLieu = Serial.readString();
    duLieu.trim();
    // Print the received data
    Serial.println(duLieu);
  }

  if (duLieu == "B1") {  // Bật LED 1
    Serial.println(duLieu);
    digitalWrite(led1, HIGH);
  } else if (duLieu == "T1") {  // Tắt LED 1
    Serial.println(duLieu);
    digitalWrite(led1, LOW);
  } else if (duLieu == "B2") {  // Bật LED 2
    Serial.println(duLieu);
    digitalWrite(led2, HIGH);
  } else if (duLieu == "T2") {  // Tắt LED 2
    Serial.println(duLieu);
    digitalWrite(led2, LOW);
  }
}
