from flask import Flask, render_template, request

app = Flask(__name__)

@app.route('/about', methods=['GET', 'POST'])
def calculate():
    result = None
    if request.method == 'POST':
        num1 = request.form.get('num1', type=int)
        num2 = request.form.get('num2', type=int)
        result = num1 + num2
    
    # Always render the same template
    return render_template('about.html', result=result)

if __name__ == '__main__':
    app.run(debug=True)