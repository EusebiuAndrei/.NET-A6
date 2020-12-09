import pandas as pd
import string
from nltk.corpus import stopwords
from wordcloud import WordCloud
from sklearn.feature_extraction.text import CountVectorizer, TfidfTransformer
from sklearn.model_selection import train_test_split
from sklearn.naive_bayes import MultinomialNB
import pickle


def load_dataset(file_path):
    return pd.read_csv(file_path)


def add_col(dataframe, col_name, col_value):
    dataframe[col_name] = col_value
    return dataframe


def combine_dataframes(*dfs):
    return pd.concat(dfs)


def shuffle_dataframe(dataframe):
    return dataframe.sample(frac=1)


def search_null_values(dataframe):
    return dataframe.isna().sum()


def create_dataframe_from_dataframe(dataframe, columns):
    return dataframe[columns]


def convert_article_to_lower_case(df_article):
    return df_article.apply(lambda x: x.lower())


def punctuation_removal(messy_str):
    punctuation = string.punctuation + "“’…–”‘"
    clean_str = messy_str.translate(str.maketrans('', '', punctuation))
    return clean_str


def remove_stopwords(df_article):
    stop = stopwords.words('english')
    return df_article.apply(lambda x: [item for item in x if item not in stop])


def create_news_tfidf(final_df):
    bow_article = CountVectorizer().fit(final_df['article'])
    article_vec = bow_article.transform(final_df['article'])
    tfidf_transformer = TfidfTransformer().fit(article_vec)
    return tfidf_transformer.transform(article_vec)


def create_NB_model(x_train, y_train):
    model_naive_bayes = MultinomialNB().fit(x_train, y_train)
    with open('pickle_NB_model.pkl', 'wb') as file:
        pickle.dump(model_naive_bayes, file)


if __name__ == '__main__':
    pd.set_option('mode.chained_assignment', None)
    # load datasets
    true_df = load_dataset('./csv-files/True.csv')
    fake_df = load_dataset('./csv-files/Fake.csv')
    # create 'classified' column which will be the target feature
    true_df = add_col(true_df, 'classified', 'TRUE')
    fake_df = add_col(fake_df, 'classified', 'FAKE')
    # combine both dataframes
    df_news = combine_dataframes(true_df, fake_df)
    # shuffle dataframe
    df_news = shuffle_dataframe(df_news)
    # searching for null values
    # print(search_null_values(df_news))
    # create article feature
    df_news = add_col(df_news, 'article', df_news['title'] + " " + df_news['text'] + " " + df_news['subject'])
    # creating the final dataframe with article and check
    df = create_dataframe_from_dataframe(df_news, ['article', 'classified'])
    # converting article values to lower case
    df['article'] = convert_article_to_lower_case(df['article'])
    # removing stopwords
    # df['article'] = remove_stopwords(df['article'])
    # removing punctuation from article column
    # df['article'] = df['article'].apply(punctuation_removal)
    # news_tfidf = create_news_tfidf(df)
    # X = news_tfidf
    # y = df['check']
    # X_train, X_test, Y_train, Y_test = train_test_split(X, y, test_size=0.2)
    # create_NB_model(X_train, Y_train)

