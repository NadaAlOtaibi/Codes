import numpy as np
import pandas as pd
import glob
import matplotlib.pyplot as plt
import seaborn as sns
import cv2

from keras.utils import to_categorical
from sklearn.preprocessing import StandardScaler
from sklearn.preprocessing import LabelEncoder

# In[2]:


def visualize(path_to_data):
    
    df = pd.read_csv(path_to_data)
    df = df.dropna()
    df = df.sort_values('PetID')
    
    #df=df.reset_index(drop=True)
    
    print(df.head())
    
    df = df.drop(['Unnamed: 0', 'Name', 'Quantity', 'RescuerID', 'VideoAmt', 'PhotoAmt'], axis=1)
    print(df.head())
    
    print(df.describe())
    
    df['AdoptionSpeed'].value_counts().plot(kind='bar', title='Training Examples by Activity Type')
    plt.show()
    
    corrmat = df.corr()
    top_corr_features = corrmat.index
    plt.figure(figsize=(20,20))
    #plot heat map
    g=sns.heatmap(df[top_corr_features].corr(),annot=True,cmap="viridis")
    
    plt.subplots(figsize=(15,15), dpi=100)
    sns.distplot( df['Age'] , color="dodgerblue", label="Age")
    sns.distplot( df['Fee'] , color="orange", label="Fee")

    plt.title('Continuous Features Histogram')
    plt.legend();
    plt.show()
    
    return df


# In[3]:


def split(data):
    
    X = data.iloc[:,:-1]
    y = data.iloc[:,-1]
    
    X.reset_index(drop=True, inplace=True)

    X, y = preprocess_data(X,y)
    
    from sklearn.model_selection import train_test_split
    
    train_X, test_X, train_y, test_y = train_test_split(X,y,test_size=0.2)
        
    return train_X, test_X, train_y, test_y


# In[4]:


def preprocess_data(X,y):
    
    label_encoder = LabelEncoder()

    t = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Type'])), dtype='int')).reset_index(drop=True)
    
    b1 = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Breed1'])), dtype='int')).reset_index(drop=True)
    b2 = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Breed2'])), dtype='int')).reset_index(drop=True)
    
    g = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Gender'])), dtype='int')).reset_index(drop=True)
    
    c1 = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Color1'])), dtype='int')).reset_index(drop=True)
    c2 = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Color2'])), dtype='int')).reset_index(drop=True)
    c3 = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Color3'])), dtype='int')).reset_index(drop=True)
    
    ms = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['MaturitySize'])), dtype='int')).reset_index(drop=True)
    
    fl = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['FurLength'])), dtype='int')).reset_index(drop=True)
    
    v = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Vaccinated'])), dtype='int')).reset_index(drop=True)
    
    d = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Dewormed'])), dtype='int')).reset_index(drop=True)
    
    s = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Sterilized'])), dtype='int')).reset_index(drop=True)
    
    h = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['Health'])), dtype='int')).reset_index(drop=True)
    
    st = pd.DataFrame(to_categorical(label_encoder.fit_transform(list(X['State']))), dtype='int').reset_index(drop=True)
    
    to_be_dropped = ['Type', 'Breed1', 'Breed2', 'Gender', 'Color1', 'Color2', 'Color3', 'MaturitySize', 'FurLength', 'Vaccinated', 'Dewormed', 'Sterilized', 'Health', 'State']
    
    X = X.drop(to_be_dropped, axis=1)
    
    train_encoded = [X,t,b1,b2,g,c1,c2,c3,ms,fl,v,d,s,h,st]
    
    X = pd.concat(train_encoded, axis=1)
    
    scaler = StandardScaler()
    
    X['Age'] = scaler.fit_transform(np.asarray(X['Age']).reshape(-1,1))
    
    X['Fee'] = scaler.fit_transform(np.asarray(X['Fee']).reshape(-1,1))
    
    y = to_categorical(y)

    return X, y


# In[5]:


def preprocess_image(train_X, test_X, path_to_images):
        
    pets = list(train_X['PetID'])
    pets.extend(list(test_X['PetID']))
    pets.sort()
    
    images = glob.glob(path_to_images + "*.jpg")
    images = sorted(images)
    images = [i for i in images if i.endswith("-1.jpg") and i.split("-1.jpg")[0].split("\\")[-1] in pets]
        
    train_images, test_images = list(), list()
    
    train_ids = list(train_X['PetID'])
    train_ids.sort()
    
    test_ids = list(test_X['PetID'])
    test_ids.sort()
    
    index_tr = 0
    index_ts = 0
    
    for i in images:
        
        if i.split("-1.jpg")[0].split("\\")[-1] == train_ids[index_tr]:
                        
            index_tr = index_tr + 1
            
            img = cv2.imread(i)
            
            img = cv2.resize(img, (32, 32), interpolation = cv2.INTER_AREA)            
            
            train_images.append(img)
            
        elif i.split("-1.jpg")[0].split("\\")[-1] == test_ids[index_ts]:
                        
            index_ts = index_ts + 1
            
            img = cv2.imread(i)
            
            img = cv2.resize(img, (32, 32), interpolation = cv2.INTER_AREA)            
            
            test_images.append(img)
                    
    train_images = np.array(train_images)
    test_images = np.array(test_images)
    
    return train_images, test_images
