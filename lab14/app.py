"""from flask import Flask, render_template

app = Flask(__name__)

@app.route('/')
def index():
    user_data = {"name": "Alex", "role": "Admin"}
    items = ["Dashboard", "Settings", "Log Out"]
    
    return render_template('index.html', user=user_data, menu=items)


if __name__ == '__main__':
    app.run(debug=True)"""


from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_admin import Admin
from flask_admin.contrib.sqla import ModelView

app = Flask(__name__)
app.config['SECRET_KEY'] = 'mysecret'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///test.db'

db = SQLAlchemy(app)


class User(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(80), unique=True)
    email = db.Column(db.String(120))

app.config['FLASK_ADMIN_SWATCH'] = 'cerulean' 
admin = Admin(app, name='My Dashboard')
admin.add_view(ModelView(User, db.session))

if __name__ == '__main__':
    with app.app_context():
        db.create_all()  
    app.run(debug=True)