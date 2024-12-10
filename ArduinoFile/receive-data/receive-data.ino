int counter = 1; // Initialize counter

void setup() {
  Serial.begin(9600); // Initialize Serial communication
  delay(1000);        // Wait for Serial to stabilize
  Serial.println("Arduino Ready!"); // Initial message
}

void loop() {
   // Send the current counter value

  while (true) {
    Serial.println(counter);
    delay(2000);             // Wait for 2 seconds
    counter++;               // Increment the counter
    if (counter > 100) {     // Reset counter after reaching 100
      counter = 1;
    }
  }
}