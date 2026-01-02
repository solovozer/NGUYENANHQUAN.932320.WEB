from flask import Blueprint, request, render_template, redirect, url_for, jsonify
from blueprints.Forms import *
import sqlite3

DB_PATH = 'site.db'

def get_conn():
    conn = sqlite3.connect(DB_PATH)
    conn.row_factory = sqlite3.Row
    return conn

lab_bp = Blueprint('lab', __name__)


@lab_bp.route('/')
def IndexLab():
    conn = get_conn()
    conn.execute('''CREATE TABLE IF NOT EXISTS lab (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL,
        address TEXT
    )''')
    cur = conn.execute('SELECT id, name, address FROM lab')
    rows = [dict(r) for r in cur.fetchall()]
    conn.close()
    return render_template('Labs/index.html', list=rows)


@lab_bp.route('/Create', methods=['GET', 'POST'])
def CreateLab():
    form = LabForm()
    if request.method == 'POST':
        name = request.form.get('name')
        address = request.form.get('address')
        conn = get_conn()
        conn.execute('INSERT INTO lab (name,address) VALUES (?,?)', (name, address))
        conn.commit()
        conn.close()
        return redirect(url_for('lab.IndexLab'))
    return render_template('Labs/create.html', form = form)

@lab_bp.route('/Edit/<int:id>', methods=['GET', 'POST'])
def EditLab(id):
    conn = get_conn()
    cur = conn.execute('SELECT id,name,address FROM lab WHERE id=?', (id,))
    row = cur.fetchone()
    conn.close()
    if not row:
        return jsonify({'error': 'not found'}), 404
    return jsonify({'id': row['id'], 'name': row['name'], 'address': row['address'], 'MESSAGE':'!!!!!!! PHOTO NOT GIVEN !!!!!!!!'})


@lab_bp.route('/Details/<int:id>', methods=['GET'])
def DetailsLab(id):
    conn = get_conn()
    cur = conn.execute('SELECT id,name,address FROM lab WHERE id=?', (id,))
    row = cur.fetchone()
    conn.close()
    temp = LabForm(data=dict(row))
    return render_template('Labs/details.html', data = temp)

@lab_bp.route('/Delete/<int:id>', methods=['POST'])
def DeleteLab(id):
    conn = get_conn()
    conn.execute('DELETE FROM lab WHERE id = ?', (id,))
    conn.commit()
    conn.close()
    return redirect(url_for('lab.IndexLab'))


