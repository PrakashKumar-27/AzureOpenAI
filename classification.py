import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import LabelEncoder
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import classification_report

# Load the tax slab data
tax_data = pd.read_csv('tax_slab_data.csv')

# Preprocess the data
# Convert categorical variables to numeric using label encoding
label_encoder = LabelEncoder()
tax_data['Location'] = label_encoder.fit_transform(tax_data['Location'])
tax_data['Designation'] = label_encoder.fit_transform(tax_data['Designation'])

# Split the data into input features (X) and target variable (y)
X = tax_data[['Salary', 'Location', 'Designation']]
y = tax_data['TaxSlab']

# Split the data into training and testing sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Train the Random Forest classifier
rf_classifier = RandomForestClassifier(n_estimators=100, random_state=42)
rf_classifier.fit(X_train, y_train)

# Make predictions on the test set
y_pred = rf_classifier.predict(X_test)

# Evaluate the model
print(classification_report(y_test, y_pred))
