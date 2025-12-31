from flask import Flask, redirect, render_template
from blueprints import ConnectRoutings

app = Flask(__name__)
app.config['SECRET_KEY'] = '123456'
ConnectRoutings(app)

@app.route('/')
def startapp():
    return redirect('/Index')

@app.route('/Index')
def index():
    return render_template('index.html')   

if __name__ == '__main__':
    app.run(debug=True)