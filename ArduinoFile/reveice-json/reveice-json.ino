#include <ArduinoJson.h>

void setup() {
  Serial.begin(115200);
  Serial.println("Connected to WiFi");
}

void loop() {
  StaticJsonDocument<200> jsonDoc;
  DeserializationError error = deserializeJson(jsonDoc, response);
  if (error) {
    Serial.println("Failed to parse JSON!");
    return;
  }

  float temperature = jsonDoc["temperature"];
  int humidity = jsonDoc["humidity"];

  Serial.print("Temperature: ");
  Serial.println(temperature);
  Serial.print("Humidity: ");
  Serial.println(humidity);
}
