from flask import Flask, redirect, render_template, session
from flask_sqlalchemy import SQLAlchemy
from database import db

app = Flask(__name__)
app.config['SECRET_KEY'] = '123456'

app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///site.db'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False 

db.init_app(app)

from blueprints import ConnectRoutings
ConnectRoutings(app)

@app.route('/')
def startapp():
    return render_template("layout.html", login = '') 

@app.route('/Mockups')
def Mockups():
    return render_template("mockups.html")


if __name__ == '__main__':
    with app.app_context(): 
        db.create_all() 
    app.run(debug=True)