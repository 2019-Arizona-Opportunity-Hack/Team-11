from flask import Flask, request
from airtable import Airtable
import json

#authentication of airtable and creation of a flask app
lessons = Airtable('appidhFGz9XaYqq9Z', 'Lessons', api_key='keyBw9IRhWe1LP6oS')
instance = Flask(__name__)

#GET function to retrieve a lesson from its title
@instance.route("/lesson/<string:title>")
def lesson(title):
    for page in lessons.get_iter():
        for item in page:
            newitem = item['fields']['title']
            if newitem == title:
                information = item['fields']
    return (json.dumps(information))

#POST method to insert lesson plans into the database
@instance.route("/postlesson/<string:user>/<string:subject>/<string:title>/<content>", methods=['GET','POST'])
def postlesson(user, subject, title, content):
    records = {'user': user, 'subject': subject, 'title': title, 'content': content}
    lessons.insert(records)
    return 'success'

if __name__ == '__main__':
	instance.run()