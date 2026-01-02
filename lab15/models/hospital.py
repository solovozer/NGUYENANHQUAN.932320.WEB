from app import db

class Hospital(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(100), nullable=False)
    address = db.Column(db.String(200))
    phone = db.Column(db.Integer)

    def __repr__(self):
        return f"<ID {self.id} Hospital {self.name} Address {self.address} Phone {self.phone}>"