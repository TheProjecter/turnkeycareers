using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.MODEL;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class KeyWordDAO : DAO_KeyWord_Interface
{
    private modelDataContext ctx;
    public KeyWordDAO()
	{
        ctx = new modelDataContext();//ModelFactory.getModelInstance();
	}





    public bool isFound(string word, string vacancyNumber)
    {

        int cnt = (from p in ctx.KeyWords
                   where p.word == @word && p.vacancyNumber == @vacancyNumber
                   select p).Count();
        if (cnt == 1)
            return true;
        else
            return false;
    }

    public KeyWordDTO find(string word, string vacancyNumber)
    {
        var obj = (from p in ctx.KeyWords
                   where p.word == @word && p.vacancyNumber == @vacancyNumber
                   select p).Single();

        KeyWordDTO add = new KeyWordDTO();
        add.vacancyNumber = obj.vacancyNumber;
        add.word = obj.word;

        return add;
    }

    public bool removeByUserId(string word, string vacancyNumber)
    {
        try
        {
            ctx.deleteKeyWords(vacancyNumber,word);

        }
        catch (Exception)
        {

        }
        return this.isFound(word, vacancyNumber);
    }

    public List<KeyWordDTO> findAll()
    {
        var objs = (from p in ctx.KeyWords
                    select p);
        KeyWordDTO add = null;
        List<KeyWordDTO> addList = new List<KeyWordDTO>();
        foreach (KeyWord obj in objs)
        {
            add = new KeyWordDTO();
            add.word = obj.word;
            add.vacancyNumber = obj.vacancyNumber;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(KeyWordDTO entity)
    {
        try
        {

            ctx.insertKeyWord(entity.vacancyNumber, entity.word);
        }
        catch (Exception)
        {
        }
        return this.isFound(entity.vacancyNumber, entity.word);
    }

    public void merge(KeyWordDTO entity)
    {
        //N/A
    }

    public bool remove(KeyWordDTO entity)
    {
        return this.removeByUserId(entity.word, entity.vacancyNumber);
    }


    bool DAO_Interface<KeyWordDTO>.merge(KeyWordDTO entity)
    {
        throw new NotImplementedException();
    }
}