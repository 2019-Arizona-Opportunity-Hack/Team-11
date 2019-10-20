from flask import Flask, request
import mysql.connector
import json

users_db = mysql.connector.connect(host = "localhost", database = "TeacherLeague", user = "root", password = "root")
cur = users_db.cursor(buffered=True)

instance = Flask(__name__)

#GET function to retrieve all information from a user from the users table given a user id
@instance.route('/users/<int:id>', methods = ['GET'])
def info(id):
    #execute SQL query
    cur.execute("SELECT * FROM `users` WHERE `id`=%i" % id)
    #getting column names from table and adding to a list
    row_headers = [x[0] for x in cur.description]
    result = cur.fetchall()
    json_data = []
    for item in result:
        json_data.append(dict(zip(row_headers,item)))
    #converting list of data to json format
    information = (json.dumps(json_data))
    return (information)

#GET function to retrieve the name of the person given a user id
@instance.route('/name/<int:id>')
def name(id):
    cur.execute("SELECT `name` FROM `users` WHERE `id`=%i" % id)
    row_headers = [x[0] for x in cur.description]
    result = cur.fetchall()
    json_data = []
    for item in result:
        json_data.append(dict(zip(row_headers,item)))
    information = (json.dumps(json_data))
    return (information)

#GET function to retrieve the bio of the user given the user id
@instance.route('/bio/<int:id>')
def bio(id):
    cur.execute("SELECT `bio` FROM `users` WHERE `id`=%i" % id)
    row_headers = [x[0] for x in cur.description]
    result = cur.fetchall()
    json_data = []
    for item in result:
        json_data.append(dict(zip(row_headers,item)))
    information = (json.dumps(json_data))
    return (information)

#GET function to retrieve the subject that is taught by the teacher with the given user id
@instance.route('/subject/<int:id>')
def subject(id):
    cur.execute("SELECT `subject` FROM `users` WHERE `id`=%i" % id)
    row_headers = [x[0] for x in cur.description]
    result = cur.fetchall()
    json_data = []
    for item in result:
        json_data.append(dict(zip(row_headers,item)))
    information = (json.dumps(json_data))
    return (information)

#GET function to retrieve the school a teacher teaches at given that teachers user id
@instance.route('/school/<int:id>')
def school(id):
    cur.execute("SELECT `school` FROM `users` WHERE `id`=%i" % id)
    row_headers = [x[0] for x in cur.description]
    result = cur.fetchall()
    json_data = []
    for item in result:
        json_data.append(dict(zip(row_headers,item)))
    information = (json.dumps(json_data))
    return (information)

#GET function to retrieve the grade level taught by the teacher with a given user id
@instance.route('/grade/<int:id>')
def grade(id):
    cur.execute("SELECT `grade` FROM `users` WHERE `id`=%i" % id)
    row_headers = [x[0] for x in cur.description]
    result = cur.fetchall()
    json_data = []
    for item in result:
        json_data.append(dict(zip(row_headers,item)))
    information = (json.dumps(json_data))
    return (information)

#POST function to fill the database with the teachers name, bio, subject taught, school taught at, and grade level
@instance.route('/putinfo/<string:name>/<string:bio>/<string:subject>/<string:school>/<string:grade>', methods=['GET','POST'])
def putinfo(name,bio,subject,school,grade):
    if request.method == 'POST':
        #executing SQL query
        cur.execute("INSERT INTO `users`(`name`, `bio`, `subject`, `school`, `grade`) VALUES (%s, %s, %s, %s, %s)",
                    (name, bio, subject, school, grade))
        #committing changes to database
        users_db.commit()
        return 'success'
    #if the method is not POST, return failure message
    else:
        return 'failure to add information'

instance.run()
