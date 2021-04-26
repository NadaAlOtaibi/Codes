import itertools
import numpy as np
import matplotlib.pyplot as plt
from Preprocess import visualize, preprocess_image, split

# In[6]:


df = visualize("D:\\petfinder-adoption-prediction\\petfinder-adoption-prediction\\dataset.csv")


# In[7]:


train_X, test_X, train_y, test_y = split(df)


# In[8]:


train_X.head()


# In[9]:


train_images, test_images = preprocess_image(train_X,test_X,"D:\\petfinder-adoption-prediction\\petfinder-adoption-prediction\\images\\")


# In[10]:


train_images.shape


# In[11]:


test_images.shape


# In[12]:


train_X.shape


# In[13]:


test_X.shape


# # Model Buidling

# In[14]:


import tensorflow as tf
from tensorflow.keras.layers import Dense
from tensorflow.keras.layers import Dropout
from tensorflow.keras import Model
from tensorflow.keras import Input
from tensorflow.keras.layers import Conv2D
from tensorflow.keras.layers import MaxPooling2D
from tensorflow.keras.layers import Flatten
from tensorflow.keras.layers import concatenate
from tensorflow.keras.utils import plot_model


# In[15]:


def create_mlp(input_dim):
    
    # define the keras model
    input_layer = Input(shape=input_dim)
    d1 = Dense(32, input_dim=input_dim, activation='relu')(input_layer)
    d2 = Dense(64, activation='relu')(d1)
    do = Dropout(0.2)(d2)
    model = Dense(32, activation='relu')(do)
    
    return (input_layer,model)


# In[16]:


def create_cnn(height, width, depth, filters=(16, 32, 64)):
    
    input_layer = Input(shape=(height,width,depth))
    cnn1 = Conv2D(filters=filters[1], kernel_size=(3,3), activation='relu')(input_layer)
    cnn2 = Conv2D(filters=filters[2], kernel_size=(3,3), activation='relu')(cnn1)
    mp = MaxPooling2D(pool_size = (2, 2))(cnn2)
    do = Dropout(0.2)(mp)
    f = Flatten()(do)
    model = Dense(32, activation='relu')(f)

    
    return (input_layer,model)


# In[17]:


def combine_cnn_mlp(mlp_model,cnn_model):
        
    # merge
    merged = concatenate([mlp_model[1], cnn_model[1]])

    # interpretation
    dense1 = Dense(32, activation='relu')(merged)
    outputs = Dense(5, activation='softmax')(dense1)
    
    model = Model(inputs=[mlp_model[0], cnn_model[0]], outputs=outputs)
    
    return model


# In[18]:


train_X = train_X.drop('PetID', axis=1)
test_X = test_X.drop('PetID', axis=1)


# In[19]:


mlp = create_mlp(train_X.shape[1])


# In[20]:


cnn = create_cnn(train_images.shape[1], train_images.shape[2], train_images.shape[3])


# In[21]:


model = combine_cnn_mlp(mlp, cnn)
model.summary()


# In[22]:


plot_model(model, to_file='model_plot.png', show_shapes=True, show_layer_names=True)


# In[23]:

def train(train_X, train_Y, model):
    
    model.compile(optimizer = 'adam', loss = 'categorical_crossentropy', metrics = ['accuracy'])
    
    numeric = train_X[0]
    images = train_X[1]
    
    history = model.fit(x=[numeric,images], y=train_Y, epochs=5, batch_size=64, validation_split=0.2)
    
    plt.title("Accuracy")
    plt.plot(history.history['accuracy'])
    plt.plot(history.history['val_accuracy'])
    plt.xlabel('Epoch')
    plt.ylabel('Accuracy')
    plt.legend(['Training', 'Validation'], loc='upper left')
    plt.show()
    
    return model


# In[24]:

# Function to plot confusion matrix
def plotConfusionMatrix(cm, classes, normalize=False, title='Confusion Matrix', cmap = plt.cm.Blues, size=(12,12)):
    
    plt.figure(figsize = size)
    plt.imshow(cm, interpolation='nearest', cmap=cmap)
    plt.title(title)
    plt.colorbar()
    tick_marks = np.arange(len(classes))
    plt.xticks(tick_marks, classes, rotation=45)
    plt.yticks(tick_marks, classes)
    
    if normalize:
        cm = cm.astype('float') / cm.sum(axis=1)[:, np.newaxis]
            
    thresh = cm.max()/2
    
    for i,j in itertools.product(range(cm.shape[0]), range(cm.shape[1])):
        plt.text(j,i, cm[i,j], horizontalalignment='center', color='white' if cm[i,j] > thresh else 'black', fontsize=20, fontweight='bold')
        plt.tight_layout()
        plt.ylabel('Actual Class')
        plt.xlabel('Predicted Class')


# In[25]:


def predict_evalute(test_X,test_Y, model):
    
    from sklearn.metrics import accuracy_score, confusion_matrix, precision_score, recall_score, f1_score
    
    numeric = test_X[0]
    images = test_X[1]
    
    y_pred = model.predict(x=[numeric,images])
    
    y_pred = np.argmax(y_pred,axis=1)
    test_Y = np.argmax(test_Y,axis=1)
    
    acc = accuracy_score(test_Y,y_pred)
    cm = confusion_matrix(test_Y,y_pred)
    ps = precision_score(test_Y,y_pred, average='weighted')
    rs = recall_score(test_Y,y_pred, average='weighted')
    f1 = f1_score(test_Y,y_pred, average='weighted')
    
    print("Accuracy: ", acc*100)
    print("Precision: ", ps*100)
    print("Recall: ", rs*100)
    print("F1 Score: ", f1*100)
    
    plotConfusionMatrix(cm,['0','1','2','3','4'])


# In[26]:


train_X.head()


# In[27]:


train_X = np.array(train_X)
test_X = np.array(test_X)


# In[28]:


model = train([train_X,train_images], train_y, model)


# In[32]:


test_images = tf.cast(test_images, tf.float32)
predict_evalute([test_X,test_images], test_y, model)

