#include <ArduinoJson.h>

void setup() {
  Serial.begin(9600); // Start Serial communication
}

void loop() {
  // Generate random temperature and humidity
  float temperature = random(1, 400) / 10.0; // Random value between 0.1 and 39.9
  int humidity = random(81, 100); // Random value between 81 and 99

  // Create a JSON object
  StaticJsonDocument<200> jsonDoc;
  jsonDoc["temperature"] = temperature;
  jsonDoc["humidity"] = humidity;

  // Serialize the JSON object to a string
  String jsonString;
  serializeJson(jsonDoc, jsonString);

  // Send the JSON string
  Serial.println(jsonString);

  delay(1000); // Wait for 1 second
}
