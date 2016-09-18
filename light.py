import requests
import sched, time

class controls:
	bridgeLights = "http://192.168.1.15/api/OvFtwPEsjav8Rf25pWrntUd7p7MBQhzyUllRch6M/lights/"
	drewHueAura = "3"
	s = sched.scheduler(time.time, time.sleep)
	
	def sendOff(self, address, light):
		result = requests.put(address + light + "/state", "{\"on\":false}")
		return result

	def sendOn(self, address, light):
		result = requests.put(address + light + "/state", "{\"on\":true}")
		return result
	
	def sendLightInformation(self, intensity, saturation, hue, light):
		address = self.bridgeLights + str(light) + "/state"
		parameters = "{\"on\":true,\"sat\":" + str(saturation) + ",\"bri\":" + str(intensity) + ",\"hue\":" + str(hue) + "}"
		result = requests.put(address, parameters)
			