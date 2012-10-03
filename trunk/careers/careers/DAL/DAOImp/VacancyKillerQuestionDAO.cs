using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class VacancyKillerQuestionDAO : DAO_VacancyKillerQuestion_Interface
{
    private ModelDataContext ctx;
    public VacancyKillerQuestionDAO()
	{
        ctx =  new ModelDataContext();//ModelFactory.getModelInstance();
	}





    public bool isFound(string question, string vacancyNumber)
    {
        try
        {
            var obj = (from p in ctx.VacancyKillerQuestions
                       where p.question == @question && p.vacancyNumber == @vacancyNumber
                       select p).Single();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public VacancyKillerQuestionDTO find(string question, string vacancyNumber)
    {
        var obj = (from p in ctx.VacancyKillerQuestions
                   where p.question == @question && p.vacancyNumber == @vacancyNumber
                   select p).Single();

        VacancyKillerQuestionDTO add = new VacancyKillerQuestionDTO();
        add.vacancyNumber = obj.vacancyNumber;
        add.question = obj.question;

        return add;
    }

    public bool removeByUserId(string question, string vacancyNumber)
    {
        try
        {
            var obj = (from p in ctx.VacancyKillerQuestions
                       where p.question == @question && p.vacancyNumber == @vacancyNumber
                       select p).Single();

            model.VacancyKillerQuestion accObj = (VacancyKillerQuestion)obj;

            ctx.VacancyKillerQuestions.DeleteOnSubmit(accObj);
            ctx.SubmitChanges();
            return true;

        }
        catch (Exception)
        {
            ctx.Dispose();
            ctx = new ModelDataContext();
            return false;
        }
    }

    public List<VacancyKillerQuestionDTO> findAll()
    {
        var objs = (from p in ctx.VacancyKillerQuestions
                    select p);
        VacancyKillerQuestionDTO add = null;
        List<VacancyKillerQuestionDTO> addList = new List<VacancyKillerQuestionDTO>();
        foreach (VacancyKillerQuestion obj in objs)
        {
            add = new VacancyKillerQuestionDTO();
            add.question = obj.question;
            add.vacancyNumber = obj.vacancyNumber;
            add.answer = obj.answer;

            addList.Add(add);
        }
        return addList;
    }

    public bool presist(VacancyKillerQuestionDTO entity)
    {
        try
        {
            model.VacancyKillerQuestion obj = new VacancyKillerQuestion();
            obj.question = entity.question;
            obj.vacancyNumber = entity.vacancyNumber;
            obj.answer = entity.answer;

            ctx.VacancyKillerQuestions.InsertOnSubmit(obj);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            ctx.Dispose();
            ctx = new ModelDataContext();
            return false;
        }
    }

    public bool merge(VacancyKillerQuestionDTO entity)
    {
        try
        {
            var addObj = (from p in ctx.VacancyKillerQuestions
                       where p.question == @entity.question && p.vacancyNumber == @entity.vacancyNumber
                       select p).Single();

            model.VacancyKillerQuestion obj = (VacancyKillerQuestion)addObj;

            /*Update*/
            obj.question = entity.question;
            obj.vacancyNumber = entity.vacancyNumber;
            obj.answer = entity.answer;

            ctx.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            model.Log log = new Log();
            log.message = "VacancyKillerQuestion Merge: " + " [" + entity.question + " , " + entity.vacancyNumber + "] " + e.Message;
            ctx.SubmitChanges();

            ctx.Dispose();
            ctx = new ModelDataContext();
            return false;
        }
    }

    public bool remove(VacancyKillerQuestionDTO entity)
    {
        return this.removeByUserId(entity.question, entity.vacancyNumber);
    }
}