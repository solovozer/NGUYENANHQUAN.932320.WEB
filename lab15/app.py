from flask import Flask, redirect, render_template
from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)
app.config['SECRET_KEY'] = '123456'

app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///site.db'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False 

db = SQLAlchemy(app)
from blueprints import ConnectRoutings
ConnectRoutings(app)

@app.route('/')
def startapp():
    return render_template("layout.html") 

if __name__ == '__main__':
    with app.app_context(): 
        db.create_all() 
    app.run(debug=True)