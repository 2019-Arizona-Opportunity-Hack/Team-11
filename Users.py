from flask import Flask, request
from airtable import Airtable
import json

#authentication of airtable and creation of a flask instance
table = Airtable('appidhFGz9XaYqq9Z', 'Users', api_key='keyBw9IRhWe1LP6oS')
instance = Flask(__name__)

#GET function to retrieve all information from a user from the users table given a name
@instance.route("/users/<string:name>")
def users(name):
    #searching for information related to a given user, converting to json and returning the result
    information = table.search('Name', name)
    return (json.dumps(information))

#GET function to retrieve school from the database given the name of a user
@instance.route("/school/<string:name>")
def school(name):
    #iterating through each page in the table and each item in the page to match the name
    for page in table.get_iter():
        for item in page:
            newitem = item['fields']['Name']
            #once the name is matched, the school is returned
            if newitem == name:
                information = item['fields']['School']
    return(json.dumps(information))

#GET function to retrieve user bio from the database given a name
@instance.route("/bio/<string:name>")
def bio(name):
    for page in table.get_iter():
        for item in page:
            newitem = item['fields']['Name']
            if newitem == name:
                information = item['fields']['Bio']
    return(json.dumps(information))

#GET function to retrieve the subject taught by a user given a name
@instance.route("/subject/<string:name>")
def subject(name):
    for page in table.get_iter():
        for item in page:
            newitem = item['fields']['Name']
            if newitem == name:
                information = item['fields']['Subject']
    return(json.dumps(information))

#GET function to retrieve the name of a user
@instance.route("/name/<string:name>")
def n(name):
    for page in table.get_iter():
        for item in page:
            newitem = item['fields']['Name']
            if newitem == name:
                information = item['fields']['Name']
    return(json.dumps(information))

#GET function to retrieve the grade level taught given a name
@instance.route("/grade/<string:name>")
def grade(name):
    for page in table.get_iter():
        for item in page:
            newitem = item['fields']['Name']
            if newitem == name:
                information = item['fields']['Grade']
    return(json.dumps(information))

#GET function to retrieve an email given the name of a user
@instance.route("/email/<string:name>")
def email(name):
    for page in table.get_iter():
        for item in page:
            newitem = item['fields']['Name']
            if newitem == name:
                information = item['fields']['Email']
    return(json.dumps(information))

#POST function to put user information into the database
@instance.route("/putinfo/<string:school>/<string:bio>/<string:subject>/<string:name>/<string:grade>/<string:email>",methods=['GET','POST'])
def putinfo(school,bio,subject,name,grade,email):
    records = {'School': school, 'Bio': bio, 'Subject': subject, 'Name': name, 'Grade': grade, 'Email': email}
    table.insert(records)
    return 'success'

if __name__ == '__main__':
	instance.run()
