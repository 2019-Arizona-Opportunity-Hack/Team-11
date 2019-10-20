import json
import re
import urllib.request

class ytMetadataGetter:
	def __init__(self, video_url):
		self.api_key = "AIzaSyCWeuSWBca0_O1gA3eu94y30zxQ4tnLt2M"
		self.snippets = ""
		self.statistics = ""
		self.video_url = video_url
		
	def id_from_url(self, url:str):
		return url.rsplit("=", 1)[1]
		
	def getSnippets(self):
		url = f"https://www.googleapis.com/youtube/v3/videos?part=snippet&id={self.id_from_url(self.video_url)}&key={self.api_key}"
		json_url = urllib.request.urlopen(url)
		self.snippets = json.loads(json_url.read())
		
	def getVideoTitle(self):
		return self.snippets["items"][0]["snippet"]["title"]
		
	def getVideoDesc(self):
		return self.snippets["items"][0]["snippet"]["description"]

	def getStatistics(self):
		url = f"https://www.googleapis.com/youtube/v3/videos?part=statistics&id={self.id_from_url(self.video_url)}&key={self.api_key}"
		json_url = urllib.request.urlopen(url)
		self.statistics = json.loads(json_url.read())

	def getNumLikes(self):
		return self.statistics["items"][0]["statistics"]["likeCount"]
		
	def getNumDislikes(self):
		return self.statistics["items"][0]["statistics"]["dislikeCount"]
		
	def getViews(self):
		return self.statistics["items"][0]["statistics"]["viewCount"]